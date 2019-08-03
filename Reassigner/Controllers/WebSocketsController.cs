using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reassigner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reassigner.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Microsoft.AspNetCore.Mvc.Route("api/ws/")]
    public class WebSocketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private static List<WebSocket> _clients = new List<WebSocket>();

        public WebSocketsController(ApplicationDbContext context)
        {
            _context = context;
            _context.DbContextChanged += _context_DbContextChanged;
        }

        private async void _context_DbContextChanged(object sender, EventArgs e)
        {
            await NotifyClients();
        }

        [HttpGet]
        public async Task Get()
        {
            var context = ControllerContext.HttpContext;
            var isSocketRequest = context.WebSockets.IsWebSocketRequest;

            if (isSocketRequest)
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                _clients.Add(webSocket);
                await NotifyClients();
            }
            else
            {
                context.Response.StatusCode = 400;
            }
        }

        private async Task NotifyClients()
        {
            var dashboard = new DashboardViewModel()
            {
                Assigned = _context.Tickets.Count(o => o.State == Infrastructure.Entities.State.Assigned),
                Unassigned = _context.Tickets.Count(o => o.State == Infrastructure.Entities.State.Unassigned),
                Rules = _context.Rules.Count(),
                Queued = _context.ReassignmentEntries.Count(o => o.CompletedTime != null)
            };

            var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new
            {
                Success = true,
                Data = new
                {
                    Dashboard = dashboard
                }
            }));
            var arraySegment = new ArraySegment<byte>(bytes);

            _clients = _clients.Where(c => c.State == WebSocketState.Open).ToList();

            foreach (var client in _clients)
            {
                await client.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
