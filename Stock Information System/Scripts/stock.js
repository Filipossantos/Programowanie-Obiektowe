function updateStockData() {
    var currentTime = new Date();

    if (lastUpdateTime && currentTime - lastUpdateTime < 2 * 60 * 1000) {
        alert("Please wait for 2 minutes before updating again.");
        return;
    }

    $.ajax({
        url: "/Stock/Update",
        type: "GET",
        success: function(response) {
            console.log(response);
            location.reload(); // Odśwież stronę po pomyślnym zakończeniu żądania
        },
        error: function() {
            alert("Error occurred while updating stock data.");
        },
        complete: function() {
            updateButton.disabled = true;
            lastUpdateTime = currentTime;

            setTimeout(function() {
                updateButton.disabled = false;
            }, 2 * 60 * 1000);
        }
    });
}
