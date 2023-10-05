$(document).ready(function () {
    $("#btn1").click(function () {
        $("#table").empty()
        $.ajax({
            method: 'GET',
            url: "Getquery1",
            success: function (lista) {
                let spedizone = ` <thead>
        <tr>
            <th scope="col">ID</th>
            <th scope="col">Data Spedizione</th>
            <th scope="col">Peso</th>
            <th scope="col">Città</th>
            <th scope="col">Indirizzo</th>
            <th scope="col">Nominativo Destinatario</th>
            <th scope="col">Costo</th>
            <th scope="col">Descrizione</th>
            <th scope="col">Data Consegna</th>
        </tr>
    </thead>
    <tbody id="a">
    </tbody>
    `
                $("#table").append(spedizone)
                $.each(lista, function (n, e) {
                    let spedizone = `
        <tr>
            <td>${e.Id}</td>
            <td>${e.DataSpedizionestring}</td>
            <td>${e.Peso}kg</td>
            <td>${e.Citta}</td>
            <td>${e.Indirizzo}</td>
            <td>${e.NominativoDestinatario}</td>
            <td>${e.costoString}</td>
            <td>${e.descrizione}</td>
            <td>${e.DataConsegnastring}
            </td>
        </tr>`

                    $("#a").append(spedizone)
                })
            }
        })
    })
    $("#btn2").click(function () {
        $("#table").empty()
        $.ajax({
            method: 'GET',
            url: "Getquery2",
            success: function (lista) {
                let spedizone = ` <thead>
        <tr>
            <th scope="col">ID</th>
            <th scope="col">Data Spedizione</th>
            <th scope="col">Peso</th>
            <th scope="col">Città</th>
            <th scope="col">Indirizzo</th>
            <th scope="col">Nominativo Destinatario</th>
            <th scope="col">Costo</th>
            <th scope="col">Descrizione</th>
            <th scope="col">Data Consegna</th>
        </tr>
    </thead>
    <tbody id="a">
    </tbody>
    `
                $("#table").append(spedizone)
                $.each(lista, function (n, e) {
                    let spedizone = `
        <tr>
            <td>${e.Id}</td>
            <td>${e.DataSpedizionestring}</td>
            <td>${e.Peso}kg</td>
            <td>${e.Citta}</td>
            <td>${e.Indirizzo}</td>
            <td>${e.NominativoDestinatario}</td>
            <td>${e.costoString}</td>
            <td>${e.descrizione}</td>
            <td>${e.DataConsegnastring}
            </td>
        </tr>`

                    $("#a").append(spedizone)
                })
            }
        })
    })
    $("#btn3").click(function () {
        $("#table").empty()
        $.ajax({
            method: 'GET',
            url: "Getquery3",
            success: function (lista) {
                let spedizone = ` <thead>
        <tr>
                <th scope="col">Città</th>
                  <th scope="col">numero clienti</th>
                   </tr>
                   </thead>
    <tbody id="a">
    </tbody>`
                $("#table").append(spedizone)
                $.each(lista, function (n, e) {
                    let spedizone = `
        <tr>
            <td>${e.Id}</td>
              <td>${e.Citta}
                </tr>
              `
                    $("#a").append(spedizone)
                })
            }
        })
    })
})