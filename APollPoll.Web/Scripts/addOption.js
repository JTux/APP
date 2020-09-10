function addOption(tableTag) {
    let index = $(tableTag).children("div").length;

    let checkBox = `
            <span class="no-display">
                <input class="check-box" data-val="true" 
                id="isValid${index}" name="Options[${index}].IsValid" 
                data-val-required="The IsValid Choice field is required."
                type="checkbox" value="true" checked>
            </span>`;

    let titleCell = `<input id='Options_${index}_Text' 
            class='form-control option-title'
            name='Options[${index}].Text' 
            type='text' />`;

    let removeCell = `<input id='del${index}'
            class='btn btn-danger option-delete'
            type='button' value='X' 
            onclick='removeRow(${index});' />`;

    let newRow = `<div id='trOption${index}'
            class='row' style='margin-bottom: 5px;'> 
                ${checkBox}${titleCell}${removeCell}
            </div>`;

    $("#optionTable").append(newRow);
}

function removeRow(id) {
    document.getElementById(`trOption${id}`).style.display = "none";
    document.getElementById(`isValid${id}`).removeAttribute("checked");
}