var connection = new signalR.HubConnectionBuilder().withUrl("/serviceHub").build();
connection.start()
    .then(() => {
        console.log("SignalR Connected");
        // Store the connection ID in sessionStorage or localStorage
        sessionStorage.setItem('signalrConnectionId', connection.connectionId);
    })
    .catch(err => console.error("SignalR Connection Error: ", err));
connection.on("AlertNewServiceCreated", function (message) {
    alert(message);
})

console.log("Welcome to user home!");