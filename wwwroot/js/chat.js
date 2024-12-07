"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");

    // Thêm margin top và bottom để tạo khoảng cách dọc
    li.style.margin = "8px 0"; // Khoảng cách trên và dưới giữa các tin nhắn

    // Kiểm tra nếu là tin nhắn của chính người dùng, căn phải
    var isCurrentUser = document.getElementById("userInput").value.trim() === user;

    // Thêm nội dung tin nhắn vào thẻ <div> bên trong <li>
    var messageDiv = document.createElement("div");
    messageDiv.style.display = "inline-block";
    messageDiv.style.padding = "8px 12px";
    messageDiv.style.borderRadius = "12px";
    messageDiv.style.maxWidth = "70%";

    if (isCurrentUser) {
        li.style.textAlign = "right"; // Căn phải cho tin nhắn của người dùng hiện tại
        messageDiv.style.backgroundColor = "#007bff";
        messageDiv.style.color = "#fff";
    } else {
        li.style.textAlign = "left"; // Căn trái cho tin nhắn của người khác
        messageDiv.style.backgroundColor = "#e9ecef";
        messageDiv.style.color = "#000";
    }

    // Gắn nội dung tin nhắn vào div
    messageDiv.textContent = message;

    // Thêm div vào li
    li.appendChild(messageDiv);

    // Thêm li vào danh sách messagesList
    document.getElementById("messagesList").appendChild(li);
});
connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    if (!user || !message) {
        alert("Vui lòng nhập tên và tin nhắn.");
        return;
    }
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();

    // Xóa nội dung input message sau khi gửi
    document.getElementById("messageInput").value = "";
});