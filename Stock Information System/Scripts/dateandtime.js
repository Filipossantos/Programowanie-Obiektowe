function showDateAndTime() {
    var date = new Date();

    var seconds = date.getSeconds();
    var minutes = date.getMinutes();
    var hour = date.getHours();
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();

    if (seconds < 10) {
        seconds = '0' + seconds;
    }

    if (minutes < 10) {
        minutes = '0' + minutes;
    }

    if (hour < 10) {
        hour = '0' + hour;
    }

    if (day < 10) {
        day = '0' + day;
    }

    if (month < 10) {
        month = '0' + month;
    }

    document.getElementById('dateAndTime').innerHTML =
        hour +
        ':' +
        minutes +
        ':' +
        seconds +
        ' | ' +
        day +
        '.' +
        month +
        '.' +
        year;

    setTimeout('showDateAndTime()', 1000);
}