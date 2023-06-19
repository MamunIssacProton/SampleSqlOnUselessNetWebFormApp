
    function handleContextChange() {
        var textBox = document.getElementById('<%= textBox.ClientID %>');
    var resultLabel = document.getElementById('<%= resultLabel.ClientID %>');

    // Update the label's text based on the new context
    resultLabel.innerText = "Context has changed! New value: " + textBox.value;
    }
