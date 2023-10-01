var connection = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.Debug)
    .withUrl("/DashboardHub", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
    })
    .build();

connection.start();

connection.on("UserAdded", (totalUsers) => {
    document.getElementById("totalUsers").innerHTML = totalUsers;
});
connection.on("ActionAdded", (totalActions) => {
    document.getElementById("totalActions").innerHTML = totalActions;
});

