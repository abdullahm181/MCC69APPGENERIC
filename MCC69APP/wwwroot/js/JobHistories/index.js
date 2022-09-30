


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
                                    <label  class="control-label">Name</label>
                                    <select  class="form-control" name="Id" id="EmployeeCreate"></select
                                </div>
                                <div class="form-group">
                                    <label class="control-label">StartDate</label>
                                    <input class="form-control" name="StartDate"/>
                                   
                                </div>
                                <div class="form-group">
                                    <label class="control-label">EndDate</label>
                                    <input class="form-control" name="EndDate"/>
                                   
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Job_Id</label>
                                    <select  class="form-control" name="Job_Id" id="JobCreate"></select
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Department_Id</label>
                                    <select  class="form-control"  name="Department_Id" id="DepartmentsCreate"></select>
                                    
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

    const Jobs = await GetAll("Jobs");
    $("#JobCreate").empty()
    $.each(Jobs, function () {
        $("#JobCreate").append($("<option />").val(this.id).text(this.jobTitle));

    });
    const Employees = await GetAll("Employees");
    $("#EmployeeCreate").empty()
    $.each(Employees, function () {
        $("#EmployeeCreate").append($("<option />").val(this.id).text(`${this.firstName} ${this.lastName}`));

    });
    const Departments = await GetAll("Departments");
    $("#DepartmentsCreate").empty()
    $.each(Departments, function () {
        $("#DepartmentsCreate").append($("<option />").val(this.id).text(this.name));

    });
    $("#Create").on("submit", async function (event) {
        var data = {};
        $('#Create').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPost = await Post("JobHistory", data);
        console.log(data);
        console.log(resultPost);
        if (resultPost == 200) {
            $('#tJobHistory').DataTable().ajax.reload();
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

    let jobHistoryDetail = await Get("JobHistory", {
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
                                    <select  class="form-control" name="Id" id="EmployeeEdit"></select
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">StartDate</label>
                                    <input " class="form-control" name="StartDate" value="${jobHistoryDetail.startDate}"/>
                                   
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">EndDate</label>
                                    <input  class="form-control" name="EndDate" value="${jobHistoryDetail.endDate}"/>
                                    
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Job_Id</label>
                                    
                                    <select class="form-control" name="Job_Id" id="JobEdit"></select>
                                    
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Department_Id</label>
                                    <select class="form-control"  name="Department_Id" id="DepartmentsEdit"></select>
                                    
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
    const Jobs = await GetAll("Jobs");
    $("#JobEdit").empty()
    $.each(Jobs, function () {
        if (this.id == jobHistoryDetail.job_Id) {
            $('#JobEdit').append(`<option value="${this.id}" selected="selected">${this.jobTitle}</option>`);
        }
        else {
            $("#JobEdit").append($("<option />").val(this.id).text(this.jobTitle));
        }

    });
    const Employees = await GetAll("Employees");
    $("#EmployeeEdit").empty()
    $.each(Employees, function () {
        if (this.id == jobHistoryDetail.manager_Id) {
            $('#EmployeeEdit').append(`<option value="${this.id}" selected="selected">${this.firstName} ${this.lastName}</option>`);
        }
        else {
            $("#EmployeeEdit").append($("<option />").val(this.id).text(`${this.firstName} ${this.lastName}`));
        }

    });
    const Departments = await GetAll("Departments");
    $("#DepartmentsEdit").empty()
    $.each(Departments, function () {
        if (this.id == jobHistoryDetail.department_Id) {
            $('#DepartmentsEdit').append(`<option value="${this.id}" selected="selected">${this.name}</option>`);
        }
        else {
            $("#DepartmentsEdit").append($("<option />").val(this.id).text(this.name));
        }

    });
    $("#Edit").on("submit", async function (event) {
        var data = {};
        $('#Edit').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPut = await Put("JobHistory", data);
        console.log(data);
        console.log(resultPut);
        if (resultPut == 200) {
            $('#tJobHistory').DataTable().ajax.reload();
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
    
    let jobHistoryDetail = await Get("JobHistory", {
        "id": id
    });
    let text = "";
    text = `
        <div class="row">
            <div class="col">
                Name
            </div>
            <div class="col">
                ${jobHistoryDetail.employees.firstName} ${jobHistoryDetail.employees.lastName}
            </div>
        </div>
        <div class="row">
            <div class="col">
                StartDate
            </div>
            <div class="col">
               ${jobHistoryDetail.employees.startDate}
            </div>
        </div>
        <div class="row">
            <div class="col">
                EndDate
            </div>
            <div class="col">
               ${jobHistoryDetail.endDate}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Jobs
            </div>
            <div class="col">
              ${jobHistoryDetail.jobs.jobTitle}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Departments
            </div>
            <div class="col">
                ${jobHistoryDetail.departments.name}
            </div>
        </div>
    
    `;
    $("#ModalTitle").text("Details");
    $("#ModalBody").html(text);
};


$(document).ready(function () {

    $('#tJobHistory').DataTable({

        dom: "<'row'<'col'l><'col'B><'col'f>>"
            + "<'row'<'col-sm-12'tr>>"
            + "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>"
        //dom: 'lBfrtip'
        ,
        buttons: [

            {
                extend: 'excelHtml5',
                name: 'excel',
                title: 'JobHistory',
                sheetName: 'JobHistory',
                text: 'download',
                className: 'btn-default',
                filename: 'DataJobHistory',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1]
                }
            }
        ],
        "ajax": {
            type: 'GET',
            url: `/JobHistory/GetAll`,
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
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.employees.firstName} ${row.employees.lastName} `;
                }
            },
            { "data": "startDate" },
            { "data": "endDate" },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row.jobs.jobTitle;
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row.departments.name;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Edit('${row.id}')">Edit</button>
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Detail('${row.id}')">Detail</button>
                        <button type="button" class="btn btn-primary" onclick="confirmDelete('tJobHistory','JobHistory',${row.id})">Delete</button>
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