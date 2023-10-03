$(document).ready(function () {
    $("#btnCerca").click(function () {
        let idSpedizione = $("#numeroOrdine").val();
        $.ajax({
            method: 'POST',
            url: 'GetPersonByNome',
            data: { numerospedizione: idSpedizione },
            success: function (data) {
                $("#table").empty()
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
    <tbody id=a>
    </tbody>
    `
                $("#table").append(spedizone)
                $.each(data, function (n, e) {
                    $("#a").empty()
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
            <td>${e.DataConsegnastring}</td>
        </tr>`

                    $("#a").append(spedizone)
                })
            }
        })
    })
})