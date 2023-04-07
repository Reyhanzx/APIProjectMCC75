$(document).ready(function () {
    const globalURL = "https://localhost:7203/api/Offices";
    $('#myTable').DataTable({
        ajax: {
            url: globalURL,
            dataSrc: "data",
            dataType: "JSON",
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { data: "city" },
            { data: "phoneNumber" },
            { data: "address1" },
            { data: "address2" },
            { data: "state" },
            { data: "country" },
            { data: "postalCode" },
            { data: "territory" },
            {
                data: "code",
                render: function (data, type, row) {
                    return `<button type="button" class="btn btn-primary btn-xs dt-edit" style="margin-right:16px;" ><i class="fas fa-pen"></i><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></button>
                            <button type="button" class="btn btn-danger btn-xs dt-delete" onclick="remove('${data}')"><i class="fas fa-trash"></i><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
                            <button class="btn btn-primary" onclick="detail(
                            '${row['city']}', 
                            '${row['phoneNumber']}',
                            '${row['address1']}',
                            '${row['address2']}', 
                            '${row['state']}',
                            '${row['country']}',
                            '${row['postalCode']}',
                            '${row['territory']}')"
                            data-bs-toggle="modal" data-bs-target="#modalDota">Detail</button>`;
                }
            },
        ],
        dom: '<"top"Bf>rt<"bottom"pli><"clear">',
        buttons: [
            { extend: 'copy', classname: 'btn btn-secondary', text: '<i class="fa-solid fa-copy"></i>' },
            { extend: 'excel', classname: 'btn btn-secondary', text: '<i class="fa-solid fa-file-excel"></i>' },
            { extend: 'pdf', classname: 'btn btn-secondary', text: '<i class="fa-solid fa-file-pdf"></i>' },
            { extend: 'colvis', classname: 'btn btn-secondary', text: '<i class="fa-solid fa-eye-slash"></i>' }
            //{
            //    extends: 'copy',
            //    text: '<i class="fa fa-files-o"></i>',
            //    titleAttr: 'Copy'
            //},
            //{
            //    extend: 'excel',
            //    text: '<i class="fa fa-file-excel-o"></i>',
            //    titleAttr: 'Excel'
            //},
            //{
            //    extend: 'csv',
            //    text: '<i class="fa fa-file-csv"></i>',
            //    titleAttr: 'CSV'
            //},
            //{
            //    extend: 'pdf',
            //    text: '<i class="fa fa-file-pdf-o"></i>',
            //    titleAttr: 'PDF'
            //},
        ]
    });
    $("#plus").html(`<button type="button" class="btn btn-danger btn-xs dt-edit" style="margin-right:16px; margin-bottom: 15px;" data-bs-toggle="modal" data-bs-target="#modalDota"
                 onclick="create()">
                    <i class="fas fa-plus"></i>
                    <span aria-hidden="true"></span>
                Tambah</button>`);

});

function detail(a, b, c, d, e, f, g, h) {
    //string interpolation
    let txt = `<li> health : ${a}</li>
               <li> health_regen : ${b}</li>
               <li>mana : ${c}</li>
               <li>mana_regen : ${d}</li>
               <li>armor : ${e}</li>
               <li>armor : ${f}</li>
               <li>base_str : ${g}</li>
               <li>base_agi : ${h}</li>`;


    $(".modal-body").html(txt);
    $("h1#examplemodallabel.modal-title").html(a);

}

function create() {
    $("#exampleModalLabel").html("Add Office");
    //$("#modalBody").html(`<form id="create" method="post" action="">
    //                <div class="form-group">
    //                    <label for="city">City</label>
    //                    <input type="text" class="city" id="city" name="city" placeholder="City" required>
    //                </div>
    //                <div class="form-group">
    //                    <label for="phoneNumber">Phone Number</label>
    //                    <input type="text" class="phoneNumber" id="phoneNumber" name="phoneNumber" placeholder="Phone Number" required>
    //                </div>
    //                <div class="form-group">
    //                    <label for="address1">Address 1</label>
    //                    <input type="text" class="address1" id="address1" name="address1" placeholder="Address 1" required>
    //                </div>
    //                <div class="form-group">
    //                    <label for="address2">Address 2</label>
    //                    <input type="text" class="address2" id="address2" name="address2" placeholder="Address 2" required>
    //                </div>
    //                <div class="form-group">
    //                    <label for="state">State</label>
    //                    <input type="text" class="state" id="state" name="state" placeholder="State" required>
    //                </div>
    //                <div class="form-group">
    //                    <label for="country">Country</label>
    //                    <input type="text" class="country" id="country" name="country" placeholder="Country" required>
    //                </div>
    //                <div class="form-group">
    //                    <label for="postalCode">Postal code</label>
    //                    <input type="text" class="postalCode" id="postalCode" name="postalCode" placeholder="Postal code" required>
    //                </div>
    //                <div class="form-group">
    //                    <label for="territory">Territory</label>
    //                    <input type="text" class="territory" id="territory" name="territory" placeholder="Territory" required>
    //                </div>
    //                <button type="submit" class="btn btn-primary" id="store">Submit</button>
    //            </form>`);
    //var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    $('#store').click(function (e) {
        e.preventDefault();
        let obj = {};
        obj.city = $("#city").val();
        obj.phoneNumber = $("#phoneNumber").val();
        obj.address1 = $("#address1").val();
        obj.address2 = $("#address2").val();
        obj.state = $("#state").val();
        obj.country = $("#country").val();
        obj.postalCode = $("#postalCode").val();
        obj.territory = $("#territory").val();

        //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
        $.ajax({
            url: "https://localhost:7203/api/Offices",
            type: "POST",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(obj)  //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
        }).done((result) => {
   
            Swal.fire({
                /*position: 'top-end',*/
                icon: 'success',
                title: 'Your work has been saved',
                showConfirmButton: false,
                timer: 1500
            })
            $('#myTable').DataTable().ajax.reload();
            $('#modalDota').modal('hide');

            //buat alert pemberitahuan jika success
        }).fail((error) => {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Something went wrong!',
                showConfirmButton: false,
                timer: 1500
               /* footer: '<a href="">Why do I have this issue?</a>'*/
            })
            $('#modalDota').modal('hide');
            //alert pemberitahuan jika gagal
        })
    })
}

function remove (requestId){
    let requestUrl = "https://localhost:7203/api/Offices?key=";
    let id = requestId;
    console.log(id);
    $.ajax({
        url: requestUrl + id,
        type: 'DELETE',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        data: id,
    }).done((result) => {

        Swal.fire({
            /*position: 'top-end',*/
            icon: 'success',
            title: 'Your work has been saved',
            showConfirmButton: false,
            timer: 1500
        })
        $('#myTable').DataTable().ajax.reload();
        $('#modalDota').modal('hide');

        //buat alert pemberitahuan jika success
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
            showConfirmButton: false,
            timer: 1500
            /* footer: '<a href="">Why do I have this issue?</a>'*/
        })
        $('#modalDota').modal('hide');
        //alert pemberitahuan jika gagal
    });
}