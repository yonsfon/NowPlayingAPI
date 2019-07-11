const uri = "api/nowplaying";
let todos = null;

function getCount(data) {
    const el = $("#counter");
    let name = "to-do";
    if (data) {
        if (data > 1) {
            name = "to-dos";
        }
        el.text(data + " " + name);
    } else {
        el.text("No " + name);
    }
}

$(document).ready(function () {
    getData();
    getData2();
});

function getData() {
    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: function (data) {
            const tBody = $("#todos");
            $(tBody).empty();
            console.log(data);
            $.each(data, function (key, item) {
                console.log(item);
                console.log(key);
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text(item))
                tr.appendTo(tBody);
            });
            todos = data;
        }
    });
}

function getData2() {
    $.ajax({
        type: "GET",
        url: "api/SongPlaying",
        cache: false,
        success: function (data) {
            const tdiv = $("#OLA");
            console.log("OLA");
            console.log(data);
            console.log(data.fullTitle);

            // const divS = $("<div></div>").text(data.fullTitle).append($("<div></div>").text("OLA"));
            // console.log(divS)

            tdiv.append($("<div></div>").text(data.fullTitle));
            tdiv.append($("<div></div>").text(data.artist));
            tdiv.append($("<div></div>").text(data.album));
            tdiv.append($("<div></div>").text(data.title));

            ola = data;
        }
    });
}


