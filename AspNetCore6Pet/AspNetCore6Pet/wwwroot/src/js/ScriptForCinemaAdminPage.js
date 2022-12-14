async function getFilms() {

    console.log("blyat");

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


async function createFilm(FilmName, priceTicket) {

    const response = await fetch("api/films", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            nameFilm: FilmName,
            ticketPrice: parseInt(priceTicket, 10)
        })
    });

    if (response.ok === true) {
        const film = await response.json();
        reset();
        document.querySelector("tbody").append(row(film));
    }

    else {
        const error = await response.json();
        console.log(error.message);
    }
}


async function editFilm(filmId, filmName, priceTicket) {
    const response = await fetch("api/films", {
        method: "PUT",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            id: filmId,
            nameFilm: filmName,
            ticketPrice: parseInt(priceTicket, 10)
        })
    });

    if (response.ok) {
        const film = await response.json();
        reset();
        document.querySelector("tr[data-rowid='" + film.id + "']").replaceWith(row(film));
    }

    else {
        const error = await response.json();
        console.log(error.message);
    }
}


async function deleteFilm(id) {
    const response = await fetch("/api/films/" + id, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });

    if (response.ok) {
        const film = await response.json();
        document.querySelector("tr[data-rowid='" + film.id + "']").remove();
    }

    else {
        const error = await response.json();
        console.log(error.message);
    }
}


function reset() {
    const form = document.forms["filmForm"];
    form.reset();
    form.elements["id"].value = 0;
}


function row(film) {

    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", film.id);

    const nameFilm = document.createElement("td");
    nameFilm.setAttribute("style", "text-align: center;");
    nameFilm.append(film.nameFilm);
    tr.append(nameFilm);

    const ticketPrice = document.createElement("td");
    ticketPrice.append(film.ticketPrice);
    ticketPrice.setAttribute("style", "text-align: center;");
    tr.append(ticketPrice);

    const linksTd = document.createElement("td");
    linksTd.setAttribute("style", "text-align: center;")

    const editLink = document.createElement("a");
    editLink.setAttribute("style", "cursor:pointer;");
    editLink.append("Изменить");
    editLink.addEventListener("click", e => {

        e.preventDefault();
        getFilm(film.id);
    });
    linksTd.append(editLink);

    const removeLink = document.createElement("a");
    removeLink.setAttribute("style", "cursor:pointer;padding-left:100px;padding-right:50px;");
    removeLink.append("Удалить");
    removeLink.addEventListener("click", e => {

        e.preventDefault();
        deleteFilm(film.id);
    });

    linksTd.append(removeLink);
    tr.appendChild(linksTd);

    return tr;
}


document.getElementById("reset").addEventListener("click", e => {
    e.preventDefault();
    reset();
})


document.forms["filmForm"].addEventListener("submit", e => {
    e.preventDefault();

    const form = document.forms["filmForm"];
    const id = form.elements["id"].value;
    const nameFilm = form.elements["nameFilm"].value;
    const ticketPrice = form.elements["ticketPrice"].value;

    if (id == 0)
        createFilm(nameFilm, ticketPrice);

    else
        editFilm(id, nameFilm, ticketPrice);
});


getFilms();