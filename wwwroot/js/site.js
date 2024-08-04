
function copyText() {
    var textToCopy = document.getElementById("textToCopy").innerText;
    var tempTextArea = document.createElement("textarea");
    tempTextArea.value = textToCopy;
    document.body.appendChild(tempTextArea);
    tempTextArea.select();
    document.execCommand("copy");
    document.body.removeChild(tempTextArea);
    showNotification("Advice copied!");
}

function showNotification(message) {
    var notification = document.getElementById("notification");
    notification.innerText = message;
    notification.className = "notification show";
    setTimeout(function () {
        notification.className = notification.className.replace("show", "");
    }, 3000);
}