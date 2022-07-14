// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let index = 0;
$("#AddSpeakerBtn").click(function () {
    index++;
    $("#SpeakersDiv").append(addNewSpeaker(index));
})
function addNewSpeaker(index) {
    let speaker = "<div class='row'>"
    speaker += "<div class='col-md-12'>";
    speaker += "<label for='speakers_" + index + "__Name' class='control-label'>Speaker Name</label>"
    speaker += "<input type='text' class='form-text' id='speakers_" + index + "__Name' name='speakers[" + index + "].Name' /> "
    speaker += "</div>"
    speaker += "<div class='col-md-12'>"
    speaker += "<label for='speakers_" + index + "__Topic' class='control-label'>Speaker Topic</label>"
    speaker += "<input type = 'text' class='form-text' id='speakers_" + index + "__Topic' name= 'speakers[" + index + "].Topic'/></div>"
    speaker +="</div> ";
    return speaker;
}