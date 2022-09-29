//GET
const GetAll = (ControllerName, BodyData = null) => $.ajax({
    type: 'GET',
    url: `/${ControllerName}/GetAll`,
    data: BodyData ? BodyData : null,
}).done(result => {

}).fail((error) => {
    console.log(error);
});

const Get = (ControllerName, BodyData = null) => $.ajax({
    type: 'GET',
    url: `/${ControllerName}/Get`,
    data: BodyData ? BodyData : null,
}).done(result => {

}).fail((error) => {
    console.log(error);
});

const PutOptions = (IdSelec, Object, SelectedId) => {
    $(`#${IdSelec}`).empty()
    $.each(Object, function () {
        if (this.id == SelectedId) {
            $(`#${IdSelec}`).append(`<option value="${this.id}" selected="selected">${this.jobTitle}</option>`);
        }
        else {
            $(`#${IdSelec}`).append($("<option />").val(this.id).text(this.jobTitle));
        }

    });
}

/*module.exports = {
    GetAll: GetAll
};*/