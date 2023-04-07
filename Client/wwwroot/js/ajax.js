//$.ajax({
//    url: "https://naruto-api.fly.dev/api/v1/characters"
//}).done((result) => {
//    console.log(result);
//    //let text = "<li>" + result.results[3].name +"</li>"
//    //$("#listPoke").html(text)
//    let text = "";
//    $.each(result, function (key, val) {
//        let img = `<img src=${val.images[0]} width = 400px >`
//        text += `<tr>
//                    <td style="color: white">${key + 1}</td>
//                    <td style="color: white">${val.name}</td>
//                    <td><button class="btn btn-primary" onclick="detail('${img}',
//                    '${val.name}',
//                    '${val.info.Aniversário}',
//                    '${val.info.Idade}',
//                    '${val.info.Altura}',
//                    '${val.info.Peso}',
//                    '${val.info.Ocupação}',
//                    '${val.info.Afiliação}',
//                    '${val.info.PatenteNinja}')
//                    " data-bs-toggle="modal" data-bs-target="#modalDota">Detail</button></td>
//                </tr>`;
//        //console.log(key);
//    })
//    $("#tbodyDota").html(text)

//});

//function detail(foto, a, b, c, d, e ,f, g, h) {

//    let txt = `${foto};
//                <li> nama : ${a}</li>
//                <li> tanggal lahir : ${b}</li>
//                <li> umur : ${c}</li>
//                <li>tinggi : ${d}</li>
//                <li>berat : ${e}</li>
//                <li>pekerjaan : ${f}</li>
//                <li> desa : ${g}</li>
//                <li> pangkat : ${h}</li>`;



//    $(".modal-body").html(txt);
//    $("h1#exampleModalLabel.modal-title").html(a);
//}


//$.ajax({
//    url: "https://api.opendota.com/api/heroStats"

//}).done((result) => {
//    console.log(result);
//    let text = "";
//    $.each(result, function (key, val) {
//        let img = `${val.img}`
//        text += `<tr>
//                    <td style="color: white"><b>${key + 1}</b></td>
//                    <td style="color: white"><b>${val.localized_name}</b></td>
//                    <td><button class="btn btn-primary" onclick="detail('${val.hero_id}',
//                    '${val.localized_name}',
//                    '${val.primary_attr}',
//                    '${val.attack_type}',
//                    '${val.roles}',
//                    'https://api.opendota.com${img}')"
//                    data-bs-toggle="modal" data-bs-target="#modalDota">Detail</button></td>
//                </tr>`;
//        /*console.log(val.img);*/
//    })
//    $("#tbodyDota").html(text)

//});

$(document).ready(function () {
    $('#myTable').DataTable({
        dom: '<"top"bft><"bottom"lpi><"clear">',
        ajax: {
    
            url: "https://api.opendota.com/api/herostats",
            dataSrc: "",
        },
       
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1
                }
            },
            { data: "name" },
            { data: "attack_type" },
            { data: "roles" },
            {
                data: "",
                render: function (data, type, row) {
                    return `<button class="btn btn-primary" onclick="detail('${row['localized_name']}', 
                    '${row['base_health']}',
                    '${row['base_health_regen']}',
                    '${row['base_mana']}', 
                    '${row['base_mana_regen']}',
                    '${row['base_armor']}',
                    '${row['base_str']}',
                    '${row['base_agi']}',
                    '${row['base_int']}',
                    '${row['attack_range']}',
                    '${row['move_speed']}',
                    'https://api.opendota.com${row['img']}')"
                    data-bs-toggle="modal" data-bs-target="#modalDota">detail</button>`;
                }
            }
        ],
        /*dom: 'bfrtip',*/
        buttons: [
            { extend: 'copy', classname: 'btn btn-secondary', text: '<i class="fa-solid fa-copy"></i>' },
            { extend: 'excel', classname: 'btn btn-secondary', text: '<i class="fa-solid fa-file-excel"></i>' },
            { extend: 'pdf', classname: 'btn btn-secondary', text: '<i class="fa-solid fa-file-pdf"></i>' },
            { extend: 'colvis', classname: 'btn btn-secondary', text: '<i class="fa-solid fa-eye-slash"></i>' }
            /*'excel', 'pdf', 'print', 'colvis',*/
            //'copy',
            //{
            //    extend: 'excel',
            //    messagetop: 'the information in this table is copyright to sirius cybernetics corp.'
            //},
            //{
            //    extend: 'pdf',
            //    messagebottom: null
            //},
            //{
            //    extend: 'print',
            //    messagetop: function () {
            //        printcounter++;

            //        if (printcounter === 1) {
            //            return 'this is the first time you have printed this document.';
            //        }
            //        else {
            //            return 'you have printed this document ' + printcounter + ' times';
            //        }
            //    },
            //    messagebottom: null
            //}
        ]

    });
});

function detail(a, b, c, d, e, f, g, h, i, j, k , l) {
    //string interpolation
    let img =`<img src=${l}>` 
    let txt = `<center>${img}</center>
               <center>${a}</center>
               <li> health : ${b}</li>
               <li> health_regen : ${c}</li>
               <li>mana : ${d}</li>
               <li>mana_regen : ${e}</li>
               <li>armor : ${f}</li>
               <li>base_str : ${g}</li>
               <li>base_agi : ${h}</li>
               <li>base_int : ${i}</li>
               <li>attact : ${j}</li>
               <li>move_speed : ${k}</li>`;


    $(".modal-body").html(txt);
    $("h1#examplemodallabel.modal-title").html(a);
}



