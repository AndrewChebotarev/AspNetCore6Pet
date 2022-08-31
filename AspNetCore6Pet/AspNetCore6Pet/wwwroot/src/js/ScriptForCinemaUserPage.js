async function getFilms() {

    const response = await fetch("/api/films", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok) {
        const films = await response.json();
        const rows = document.querySelector("tbody");

        films.forEach(film => rows.append(row(film)));
    }
}


async function getFilm(id) {

    const response = await fetch("/api/films/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok) {
        const film = await response.json();
        const films = document.forms["filmForm"];

        films.elements["id"].value = film.id;
        films.elements["nameFilm"].value = film.nameFilm;
        films.elements["ticketPrice"].value = film.ticketPrice;
    }

    else {
        const error = await response.json();
        console.log(error.message);
    }
}


function row(film) {

    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", film.id);

    const filmName = document.createElement("td");
    filmName.setAttribute("style", "text-align: center;");
    filmName.append(film.nameFilm);
    tr.append(filmName);

    const ticketPrice = document.createElement("td");
    ticketPrice.append(film.ticketPrice);
    ticketPrice.setAttribute("style", "text-align: center;");
    tr.append(ticketPrice);

    return tr;
}

getFilms();