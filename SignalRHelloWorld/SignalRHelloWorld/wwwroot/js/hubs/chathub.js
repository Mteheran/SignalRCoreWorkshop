"use strict";

var con = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
document.getElementById("chatSubmit").addEventListener("click",
function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    con.invoke("sendMessage", { User: user, Message: message });
    event.preventDefault();

});

con.start().catch(function (err) {
    return console.error(err.toString());
});

con.on("RecieveMessage",
              function (chatMessage) {
                  var li = document.createElement("li");
                  li.textContent = chatMessage.user + " - " + chatMessage.message;
                  document.getElementById("messageHistory").appendChild(li);
                  document.getElementById("chatConnection").innerText = "Desconectar";
                  document.getElementById("chatConnection").setAttribute("data-connection", "On");
              }
);

document.getElementById("chatConnection").addEventListener("click",
function (event) {
    
        con.stop();    
        event.preventDefault();

    }       );

