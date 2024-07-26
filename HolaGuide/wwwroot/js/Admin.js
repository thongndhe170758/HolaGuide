
const connection = new signalR.HubConnectionBuilder().withUrl("/serviceHub").build();

connection.start()
    .then(() => {
        console.log("connected");
    })
    .catch(err => console.error("SignalR Connection Error: ", err));

document.addEventListener('DOMContentLoaded', function () {
    var myForm = document.getElementById('myForm');

    // Add submit event listener to the form
    myForm.addEventListener('submit', function (event) {
        event.preventDefault();

        // Store the form for later use
        var form = this;

        // Invoke SignalR method
        connection.invoke('NewServiceCreated').then(function () {
            console.log('SignalR invoke successfully');

            // Submit the form manually using JavaScript
            form.submit();
        }).catch(function (error) {
            console.log('Cannot invoke', error);
        });
    });
});

