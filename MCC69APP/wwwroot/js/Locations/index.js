


async function Create() {
    //console.log("Test masuk create")

    let text = "";
    text = `
        <div class="addselection">
            <div class="row">
                        <div class="col">
                            <form id="Create" method="POST" action="javascript:void(0);">
                                <div  class="text-danger"></div>
                                <input type="hidden" asp-for="Id" />
                                <div class="form-group">
                                    <label class="control-label">StreetAddress</label>
                                    <input class="form-control" name="StreetAddress"/>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">PostalCode</label>
                                    <input class="form-control" name="PostalCode" />

                                </div>

                                <div class="form-group">
                                    <label class="control-label">City</label>
                                    <input class="form-control" name="City"/>
                                   
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Country_Id</label>
                                    <select  class="form-control" name="Country_Id" id="CountryCreate"></select
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

    const Countries = await GetAll("Countries");
    $("#CountryCreate").empty()
    $.each(Countries, function () {
        $("#CountryCreate").append($("<option />").val(this.id).text(this.streetAddress));

    });
    $("#Create").on("submit", async function (event) {
        var data = {};
        data["Id"] = 0;
        $('#Create').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPost = await Post("Locations", data);
        console.log(data);
        console.log(resultPost);
        if (resultPost == 200) {
            $('#tLocations').DataTable().ajax.reload();
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

    let locationDetail = await Get("Locations", {
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
                                    <label  class="control-label">StreetAddress</label>
                                    <input class="form-control" name="StreetAddress" value="${locationDetail.streetAddress}" />
                                    
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">PostalCode</label>
                                    <input " class="form-control" name="PostalCode" value="${locationDetail.postalCode}"/>
                                   
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">City</label>
                                    <input  class="form-control" name="City" value="${locationDetail.city}"/>
                                    
                                </div>
                                
                                <div class="form-group">
                                    <label  class="control-label">Country_Id</label>
                                    
                                    <select class="form-control" name="Country_Id" id="CountryEdit"></select>
                                    
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
    const Countries = await GetAll("Countries");
    $("#CountryEdit").empty()
    $.each(Countries, function () {
        if (this.id == locationDetail.job_Id) {
            $('#CountryEdit').append(`<option value="${this.id}" selected="selected">${this.streetAddress}</option>`);
        }
        else {
            $("#CountryEdit").append($("<option />").val(this.id).text(this.streetAddress));
        }

    });
    $("#Edit").on("submit", async function (event) {
        var data = {};
        data["Id"] = locationDetail.id;
        $('#Edit').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPut = await Put("Locations", data);
        console.log(data);
        console.log(resultPut);
        if (resultPut == 200) {
            $('#tLocations').DataTable().ajax.reload();
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
    
    let locationDetail = await Get("Locations", {
        "id": id
    });
    let text = "";
    text = `
        <div class="row">
            <div class="col">
                StreetAddress
            </div>
            <div class="col">
                ${locationDetail.streetAddress}
            </div>
        </div>
        <div class="row">
            <div class="col">
                PostalCode
            </div>
            <div class="col">
               ${locationDetail.postalCode}
            </div>
        </div>
        <div class="row">
            <div class="col">
                City
            </div>
            <div class="col">
               ${locationDetail.city}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Countries
            </div>
            <div class="col">
              ${locationDetail.countries.name}
            </div>
        </div>
       
    
    `;
    $("#ModalTitle").text("Details");
    $("#ModalBody").html(text);
};


$(document).ready(function () {

    $('#tLocations').DataTable({

        dom: "<'row'<'col'l><'col'B><'col'f>>"
            + "<'row'<'col-sm-12'tr>>"
            + "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>"
        //dom: 'lBfrtip'
        ,
        buttons: [

            {
                extend: 'excelHtml5',
                name: 'excel',
                title: 'Locations',
                sheetName: 'Locations',
                text: 'download',
                className: 'btn-default',
                filename: 'DataLocations',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1]
                }
            }
        ],
        "ajax": {
            type: 'GET',
            url: `/Locations/GetAll`,
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
            { "data": "streetAddress" },
            { "data": "postalCode" },
            { "data": "city" },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row.countries.name;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Edit('${row.id}')">Edit</button>
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Detail('${row.id}')">Detail</button>
                        <button type="button" class="btn btn-primary" onclick="confirmDelete('tLocations','Locations',${row.id})">Delete</button>
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