
    function copyText() {
        var textToCopy = document.getElementById("textToCopy").innerText;
        var tempTextArea = document.createElement("textarea");
        tempTextArea.value = textToCopy;
        document.body.appendChild(tempTextArea);
        tempTextArea.select();
        document.execCommand("copy");
        document.body.removeChild(tempTextArea);
        alert("Advice copied!");
    }
