


async function Create() {
    let text = "";
    text = `
        <div class="addselection">
            <div class="row">
                        <div class="col">
                            <form id="Create" method="POST" action="javascript:void(0);">
                                <div  class="text-danger"></div>
                                <input type="hidden" asp-for="Id" />
                                <div class="form-group">
                                    <label class="control-label">Name</label>
                                    <input class="form-control" name="Name" />
                                   
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Regions</label>

                                    <select class="form-control" name="Region_Id" id="RegionsCreate"></select>

                                </div>
                                <div class="form-group">
                                    <input type="submit" value="Save" class="btn btn-primary" />
                                </div>
                            </form>
                        </div>
                    </div>
        </div
    `;
    $("#ModalTitle").text("Create");
    $("#ModalBody").html(text);

    const Regions = await GetAll("Regions");
    $("#RegionsCreate").empty()
    $.each(Regions, function () {
        $("#RegionsCreate").append($("<option />").val(this.id).text(this.name));

    });
    $("#Create").on("submit", async function (event) {
        var data = {};
        data["Id"] = 0;
        $('#Create').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPost = await Post("Countries", data);
        console.log(data);
        console.log(resultPost);
        if (resultPost == 200) {
            $('#tCountries').DataTable().ajax.reload();
            $('#ModalData').modal('hide');
        }
        swal(
            'Success',
            'Data Telah Ditambahkan',
            'success'
        )
        event.preventDefault();

    });
};

async function Edit(id) {

    let countryDetail = await Get("Countries", {
        "id": id
    });
    let text = "";
    text = `
        <div class="addselection">
            <div class="row">
                        <div class="col">
                            <form id="Edit" method="POST" action="javascript:void(0);">
                                <div  class="text-danger"></div>
                                <input type="hidden" asp-for="Id" />
                                <div class="form-group">
                                    <label  class="control-label">Name</label>
                                    <input class="form-control" name="Name" value="${countryDetail.name}" />
                                    
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Regions</label>
                                    
                                    <select class="form-control" name="Region_Id" id="RegionsEdit"></select>
                                    
                                </div>
                                <div class="form-group">
                                    <input type="submit" value="Save" class="btn btn-primary" />
                                </div>
                            </form>
                        </div>
                    </div>
        </div
        
    `

    $("#ModalTitle").text("Edit");
    $("#ModalBody").html(text);
    const Regions = await GetAll("Regions");
    $("#RegionsEdit").empty()
    $.each(Regions, function () {
        if (this.id == countryDetail.region_Id) {
            $('#RegionsEdit').append(`<option value="${this.id}" selected="selected">${this.name}</option>`);
        }
        else {
            $("#RegionsEdit").append($("<option />").val(this.id).text(this.name));
        }

    });
    $("#Edit").on("submit", async function (event) {
        var data = {};
        data["Id"] = countryDetail.id;
        $('#Edit').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPut = await Put("Countries", data);
        console.log(data);
        console.log(resultPut);
        if (resultPut == 200) {
            $('#tCountries').DataTable().ajax.reload();
            $('#ModalData').modal('hide');
        }
        swal(
            'Success',
            'Data Telah Berubah',
            'success'
        )
        event.preventDefault();

    });
   
    
};
async function Detail(id) {
    
    let countryDetail = await Get("Countries", {
        "id": id
    });
    let text = "";
    text = `
        <div class="row">
            <div class="col">
                Name
            </div>
            <div class="col">
                ${countryDetail.name}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Regions
            </div>
            <div class="col">
               ${countryDetail.regions.name}
            </div>
        </div>
    
    `;
    $("#ModalTitle").text("Details");
    $("#ModalBody").html(text);
};


$(document).ready(function () {

    $('#tCountries').DataTable({

        dom: "<'row'<'col'l><'col'B><'col'f>>"
            + "<'row'<'col-sm-12'tr>>"
            + "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>"
        //dom: 'lBfrtip'
        ,
        buttons: [

            {
                extend: 'excelHtml5',
                name: 'excel',
                title: 'Countries',
                sheetName: 'Countries',
                text: 'download',
                className: 'btn-default',
                filename: 'DataCountries',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1]
                }
            }
        ],
        "ajax": {
            type: 'GET',
            url: `/Countries/GetAll`,
            dataSrc: "",
            dataType: "JSON"
        },
        "columns": [
            {
                "data": null,
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { "data": "name" },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row.regions.name;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Edit('${row.id}')">Edit</button>
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Detail('${row.id}')">Detail</button>
                        <button type="button" class="btn btn-primary" onclick="confirmDelete('tCountries','Countries',${row.id})">Delete</button>
                    `;
                }
            }
        ]
    });
    

    // Example starter JavaScript for disabling form submissions if there are invalid fields
    (function () {
        'use strict'

        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.querySelectorAll('.needs-validation')
        //$("#contact-form").validator();
        // Loop over them and prevent submission
        Array.prototype.slice.call(forms)
            .forEach(function (form) {
                form.addEventListener('submit', function (event) {
                    if (!form.checkValidity()) {
                        swal(
                            'Error!',
                            'You clicked the <b style="color:red;">error</b> button!',
                            'error'
                        )
                        event.preventDefault()
                        event.stopPropagation()
                    }
                    form.classList.add('was-validated')
                }, false)
            })
        $("#contact-form").on("submit", function (e) {
            // if the validator does not prevent form submit
            if (!e.isDefaultPrevented()) {
                swal(
                    'Success',
                    'You clicked the <b style="color:green;">Success</b> button!',
                    'success'
                )
            }
        });
    })();
});