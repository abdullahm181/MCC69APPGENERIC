//GET
const GetAll = (ControllerName, BodyData = null) => $.ajax({
    type: 'GET',
    url: `/${ControllerName}/GetAll`,
    data: BodyData ? BodyData : null,
}).done(result => {

}).fail((error) => {
    console.log(error);
});

/*module.exports = {
    GetAll: GetAll
};*/