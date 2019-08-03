function subscribeWS(wstarget) {
    let ws = new WebSocket('ws://' + window.location.host.toString() + "/api/ws");
    ws.onmessage = function (message) {
        let data = JSON.parse(message.data);
        if (data.Success) {
            if (wstarget === "dashboard") {
                setValues("rv", "rd", "Rule", data.Dashboard.Rules);
                setValues("qv", "qd", "Queued ticket", data.Dashboard.Queued);
                setValues("uv", "ud", "Unassigned ticket", data.Dashboard.Queued);
                setValues("av", "ad", "Assigned ticket", data.Dashboard.Assigned);
                setValues("tv", "td", "Total ticket", data.Dashboard.Assigned + data.Dashboard.Unassigned);
                buildChart(data.Dashboard.Queued, data.Dashboard.Unassigned, data.Dashboard.Assigned);
            }
            else if (wstarget === "rules") {
                console.log(data);
            }
            else if (wstarget === "agents") {
                console.log(data);
            }
            else if (wstarget === "reports") {
                console.log(data);
            }
        }
        else {
            console.log({ "Description": "Error parsing websockets message.", "Data": message });
        }
    };
}

function setValues(ival, idesc, word, val) {
    $("#" + ival).html(val);
    $("#" + idesc).html(word + (val !== 1) ? "s" : "");
}