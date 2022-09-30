


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
                                    <label class="control-label">JobTitle</label>
                                    <input class="form-control" name="JobTitle" />
                                   
                                </div>
                                <div class="form-group">
                                    <label class="control-label">MinSalary</label>
                                    <input class="form-control" name="MinSalary" />

                                </div>
                                <div class="form-group">
                                    <label class="control-label">MaxSalary</label>
                                    <input class="form-control" name="MaxSalary" />

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

    $("#Create").on("submit", async function (event) {
        var data = {};
        data["Id"] = 0;
        $('#Create').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPost = await Post("Jobs", data);
        console.log(data);
        console.log(resultPost);
        if (resultPost == 200) {
            $('#tJobs').DataTable().ajax.reload();
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

    let jobDetail = await Get("Jobs", {
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
                                    <label  class="control-label">JobTitle</label>
                                    <input class="form-control" name="JobTitle" value="${jobDetail.jobTitle}" />
                                    
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">MinSalary</label>
                                    <input class="form-control" name="MinSalary" value="${jobDetail.minSalary}" />

                                </div>
                                <div class="form-group">
                                    <label  class="control-label">MaxSalary</label>
                                    <input class="form-control" name="MaxSalary" value="${jobDetail.maxSalary}" />

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
    $("#Edit").on("submit", async function (event) {
        var data = {};
        data["Id"] = jobDetail.id;
        $('#Edit').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPut = await Put("Jobs", data);
        console.log(data);
        console.log(resultPut);
        if (resultPut == 200) {
            $('#tJobs').DataTable().ajax.reload();
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

    let jobDetail = await Get("Jobs", {
        "id": id
    });
    let text = "";
    text = `
        <div class="row">
            <div class="col">
                Id
            </div>
            <div class="col">
                ${jobDetail.id}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Name
            </div>
            <div class="col">
               ${jobDetail.jobTitle}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Name
            </div>
            <div class="col">
               ${jobDetail.minSalary}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Name
            </div>
            <div class="col">
               ${jobDetail.maxSalary}
            </div>
        </div>
    `;
    $("#ModalTitle").text("Details");
    $("#ModalBody").html(text);
};


$(document).ready(function () {

    $('#tJobs').DataTable({

        dom: "<'row'<'col'l><'col'B><'col'f>>"
            + "<'row'<'col-sm-12'tr>>"
            + "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>"
        //dom: 'lBfrtip'
        ,
        buttons: [

            {
                extend: 'excelHtml5',
                name: 'excel',
                title: 'Jobs',
                sheetName: 'Jobs',
                text: 'download',
                className: 'btn-default',
                filename: 'DataJobs',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1]
                }
            }
        ],
        "ajax": {
            type: 'GET',
            url: `/Jobs/GetAll`,
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
            { "data": "jobTitle" },
            { "data": "minSalary" },
            { "data": "maxSalary" },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Edit('${row.id}')">Edit</button>
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Detail('${row.id}')">Detail</button>
                        <button type="button" class="btn btn-primary" onclick="confirmDelete('tJobs','Jobs',${row.id})">Delete</button>
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