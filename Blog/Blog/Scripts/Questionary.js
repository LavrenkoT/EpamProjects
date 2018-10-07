function openView(data)
{
    var form = document.getElementById('questionaryForm');
    form.style.display = 'none';
    form.insertAdjacentHTML('afterend', data);
};

function httpGetAsync(url, callback, ) {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
            callback(xmlHttp.responseText);
        }
    };

    xmlHttp.open("GET", url, true);
    xmlHttp.send(null);
}

function openPreview() {
    var url = "/Questionary/Action",
        name = document.getElementById('Name').value,
        gender = document.querySelector('input[name="Gender"]:checked').value,
        sports = document.querySelectorAll('input[name="Sports"]:checked');

    url = url + "?name=" + name;
    url = url + "&gender=" + gender;

    for (var key in sports) {
        if (sports.hasOwnProperty(key)) {
            url = url + "&sports=" + sports[key].value;
        }
    }

    httpGetAsync(url, openView, showError);
};

function showError(error) {
    alert(error);
};