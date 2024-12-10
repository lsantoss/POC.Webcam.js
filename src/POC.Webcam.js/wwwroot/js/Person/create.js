// Global variables
var image = "";
var editedImage = "";
var imageCaptureMode = "webcam";

// When loading the page configures the webcam
window.onload = function () {
    Webcam.set({
        width: 225,
        height: 225,
        image_format: 'png'
    });
    Webcam.attach('#divWebcam');
}

// Populate the div for using the webcam
function showWebcam() {
    imageCaptureMode = "webcam";
    document.getElementById("radioWebcam").checked = true;
    document.getElementById("radioInputFile").checked = false;

    let divWebcamColMd6 = document.createElement("div");
    divWebcamColMd6.setAttribute("class", "col-md-6");

    let divWebcamPanelDefault = document.createElement("div");
    divWebcamPanelDefault.setAttribute("class", "panel panel-default");

    let divWebcamPanelHeading = document.createElement("div");
    divWebcamPanelHeading.setAttribute("class", "panel-heading");
    divWebcamPanelHeading.innerText = "Camera";

    let divWebcamPanelBody = document.createElement("div");
    divWebcamPanelBody.setAttribute("class", "panel-body");

    let divWebcam = document.createElement("div");
    divWebcam.setAttribute("id", "divWebcam");
    divWebcam.setAttribute("class", "center-block");

    let divWebcamInputButtonTakePicture = document.createElement("input");
    divWebcamInputButtonTakePicture.setAttribute("type", "button");
    divWebcamInputButtonTakePicture.setAttribute("class", "btn btn-primary");
    divWebcamInputButtonTakePicture.setAttribute("value", "Take picture");
    divWebcamInputButtonTakePicture.setAttribute("onClick", "takePicture()");

    divWebcamColMd6.appendChild(divWebcamPanelDefault);
    divWebcamPanelDefault.appendChild(divWebcamPanelHeading);
    divWebcamPanelDefault.appendChild(divWebcamPanelBody);
    divWebcamPanelBody.appendChild(divWebcam);
    divWebcamPanelBody.appendChild(document.createElement("br"));
    divWebcamPanelBody.appendChild(divWebcamInputButtonTakePicture);

    let divResultColMd6 = document.createElement("div");
    divResultColMd6.setAttribute("class", "col-md-6");

    let divResultPanelDefault = document.createElement("div");
    divResultPanelDefault.setAttribute("class", "panel panel-default");

    let divResultPanelHeading = document.createElement("div");
    divResultPanelHeading.setAttribute("class", "panel-heading");
    divResultPanelHeading.innerText = "Final picture";

    let divResultPanelBody = document.createElement("div");
    divResultPanelBody.setAttribute("class", "panel-body");

    let divResultImage = document.createElement("div");
    divResultImage.setAttribute("id", "imageResult");
    divResultImage.style.cssText = "height:160px;";

    divResultColMd6.appendChild(divResultPanelDefault);
    divResultPanelDefault.appendChild(divResultPanelHeading);
    divResultPanelDefault.appendChild(divResultPanelBody);
    divResultPanelBody.appendChild(divResultImage);

    document.getElementById('divChoice').innerHTML = "";
    document.getElementById('divChoice').appendChild(divWebcamColMd6);
    document.getElementById('divChoice').appendChild(divResultColMd6);

    image = "";
    editedImage = "";
    document.getElementById('imageBase64StringField').value = "";

    Webcam.set({
        width: 225,
        height: 225,
        image_format: 'png'
    });
    Webcam.attach('#divWebcam');
}

// Populate the div for using the input type file
function showInputFile() {
    Webcam.reset();

    imageCaptureMode = "inputFile";
    document.getElementById("radioWebcam").checked = false;
    document.getElementById("radioInputFile").checked = true;

    let divPainelDefault = document.createElement("div");
    divPainelDefault.setAttribute("class", "panel panel-default");

    let divColMd12 = document.createElement("div");
    divColMd12.setAttribute("class", "col-md-12");

    let divPainelHeading = document.createElement("div");
    divPainelHeading.setAttribute("class", "panel-heading");
    divPainelHeading.innerText = "Upload image";

    let divPainelBody = document.createElement("div");
    divPainelBody.setAttribute("class", "panel-body");

    let p = document.createElement("p");
    p.innerText = "We recommend choosing an image of 140x180 size and .png format";

    let divUploadBtnWrapper = document.createElement("div");
    divUploadBtnWrapper.setAttribute("class", "upload-btn-wrapper");

    let btnUpload = document.createElement("button");
    btnUpload.setAttribute("class", "btn btnUpload");
    btnUpload.setAttribute("id", "btnInputFile");

    let imgBtnUpload = document.createElement("img");
    imgBtnUpload.setAttribute("src", "/images/upload-cloud.png");
    imgBtnUpload.style.cssText = "width:90px; height:90px;";

    let brBtnUpload = document.createElement("br");

    let pBtnUpload = document.createElement("p");
    pBtnUpload.innerHTML = "Drag the image here<br/> or <br/> Click to find one<br/> on your device";

    let inputFile = document.createElement("input");
    inputFile.setAttribute("type", "file");
    inputFile.setAttribute("accept", "image/*");
    inputFile.setAttribute("onchange", "getFileFromInputFile(this)");

    divPainelDefault.appendChild(divColMd12);
    divColMd12.appendChild(divPainelHeading);
    divColMd12.appendChild(divPainelBody);
    divPainelBody.appendChild(p);
    divPainelBody.appendChild(divUploadBtnWrapper);
    btnUpload.append(imgBtnUpload);
    btnUpload.append(brBtnUpload);
    btnUpload.append(pBtnUpload);
    divUploadBtnWrapper.appendChild(btnUpload);
    divUploadBtnWrapper.appendChild(inputFile);

    document.getElementById('divChoice').innerHTML = "";
    document.getElementById('divChoice').appendChild(divPainelDefault);

    image = "";
    editedImage = "";
    document.getElementById('imageBase64StringField').value = "";
}

// Capture image by clicking "Take Picture" button
// Show imageResult on page
// #imageBase64StringField receives the treated base64String of the last photo taken
function takePicture() {
    Webcam.snap(
        function (imageBase64String) {
            image = imageBase64String;
            editedImage = imageBase64String;
            showModalImageCustomization(imageBase64String);
        }
    );
}

// Create element and show image in edit modal
function showModalImageCustomization(imageBase64String) {
    let img = document.createElement("img");
    img.setAttribute("src", `${imageBase64String}`);
    img.setAttribute("class", "mt-4 mb-2");
    img.style.cssText = "width:55%; heigth:55%; margin-left:110px;";

    document.getElementById('bodyModalImageCustomization').innerHTML = "";
    document.getElementById('bodyModalImageCustomization').appendChild(img);

    $('#modalImageCustomization').modal('show');
}

// Right image rotation
function turnRight() {
    var imgOriginal = new Image();
    imgOriginal.src = editedImage;

    var canvas = document.createElement("canvas");

    if (imgOriginal.height > imgOriginal.width) {
        canvas.width = imgOriginal.height;
        canvas.height = imgOriginal.height;
    }

    if (imgOriginal.width > imgOriginal.height) {
        canvas.width = imgOriginal.width;
        canvas.height = imgOriginal.width;
    }

    if (imgOriginal.width === imgOriginal.height) {
        canvas.width = imgOriginal.width;
        canvas.height = imgOriginal.height;
    }

    var ctx = canvas.getContext("2d");
    ctx.translate(canvas.width / 2, canvas.height / 2);

    // create splash image
    var image = document.createElement("img");
    image.src = imgOriginal.src;

    // clear canvas, rotate and draw image in center
    ctx.clearRect(-canvas.width, -canvas.height, canvas.width * 2, canvas.height * 2);
    ctx.rotate(90 * Math.PI / 180);
    ctx.drawImage(image, -image.width / 2, -image.width / 2);

    // create new image in html
    var img = document.createElement('img');
    img.src = canvas.toDataURL("image/png");
    editedImage = img.src;
    showModalImageCustomization(editedImage);
}

// Left image rotation
function turnLeft() {
    var imgOriginal = new Image();
    imgOriginal.src = editedImage;

    var canvas = document.createElement("canvas");

    if (imgOriginal.height > imgOriginal.width) {
        canvas.width = imgOriginal.height;
        canvas.height = imgOriginal.height;
    }

    if (imgOriginal.width > imgOriginal.height) {
        canvas.width = imgOriginal.width;
        canvas.height = imgOriginal.width;
    }

    if (imgOriginal.width === imgOriginal.height) {
        canvas.width = imgOriginal.width;
        canvas.height = imgOriginal.height;
    }

    var ctx = canvas.getContext("2d");
    ctx.translate(canvas.width / 2, canvas.height / 2);

    // create splash image
    var image = document.createElement("img");
    image.src = imgOriginal.src;

    // clear canvas, rotate and draw image in center
    ctx.clearRect(-canvas.width, -canvas.height, canvas.width * 2, canvas.height * 2);
    ctx.rotate(-90 * Math.PI / 180);
    ctx.drawImage(image, -image.width / 2, -image.width / 2);

    // create new image in html
    var img = document.createElement('img');
    img.src = canvas.toDataURL("image/png");
    editedImage = img.src;
    showModalImageCustomization(editedImage);
}

// Increases image brightness
function increaseBrightness() {
    var imgOriginal = new Image();
    imgOriginal.src = editedImage;

    var canvas = document.createElement("canvas");
    canvas.width = imgOriginal.width;
    canvas.height = imgOriginal.height;

    var ctx = canvas.getContext("2d");

    // create splash image
    var image = document.createElement("img");
    image.src = imgOriginal.src;

    // clean canvas and apply more brightness to the image
    ctx.filter = "brightness(105%)";
    ctx.drawImage(image, 0, 0);

    // create new image in html
    var img = document.createElement('img');
    img.src = canvas.toDataURL("image/png");
    editedImage = img.src;
    showModalImageCustomization(editedImage);
}
showInputFileModifications
// Decrease the brightness of the image
function decreaseBrightness() {
    var imgOriginal = new Image();
    imgOriginal.src = editedImage;

    var canvas = document.createElement("canvas");
    canvas.width = imgOriginal.width;
    canvas.height = imgOriginal.height;

    var ctx = canvas.getContext("2d");

    // create splash image
    var image = document.createElement("img");
    image.src = imgOriginal.src;

    // clean canvas and apply less brightness to the image
    ctx.filter = "brightness(95%)";
    ctx.drawImage(image, 0, 0);

    // create new image in html
    var img = document.createElement('img');
    img.src = canvas.toDataURL("image/png");
    editedImage = img.src;
    showModalImageCustomization(editedImage);
}

// Apply black and white filter on image
function addFilterBlackWhite() {
    var imgOriginal = new Image();
    imgOriginal.src = editedImage;

    var canvas = document.createElement("canvas");
    canvas.width = imgOriginal.width;
    canvas.height = imgOriginal.height;

    var ctx = canvas.getContext("2d");

    // create splash image
    var image = document.createElement("img");
    image.src = imgOriginal.src;

    // clean canvas and apply black and white filter on image
    ctx.filter = "grayscale(100%)";
    ctx.drawImage(image, 0, 0);

    // create new image in html
    var img = document.createElement('img');
    img.src = canvas.toDataURL("image/png");
    editedImage = img.src;
    showModalImageCustomization(editedImage);
}

// Restore the original image
function undoChanges() {
    editedImage = image;
    showModalImageCustomization(editedImage);
}

// Discard all changes made to the image
function cancelModifications() {
    image = "";
    editedImage = "";
    document.getElementById('bodyModalImageCustomization').innerHTML = "";
}

// Shows the result of the image after being edited with a filter in the modal
// According to the variable "imageCaptureMode" the function that creates the elements will be called
function confirmModifications() {
    if (imageCaptureMode === "webcam") {
        showWebcamModifications();
    }
    else {
        showInputFileModifications();
	}
}

// Create elements with the result of editing the form - Webcam
function showWebcamModifications() {
    let br1 = document.createElement("br");

    let img = document.createElement("img");
    img.setAttribute("src", `${editedImage}`);
    img.setAttribute("class", "center-block");
    img.setAttribute("width", "225px");
    img.setAttribute("height", "175px");

    let br2 = document.createElement("br");
    let br3 = document.createElement("br");
    let br4 = document.createElement("br");

    let inputButton = document.createElement("input");
    inputButton.setAttribute("type", "button");
    inputButton.setAttribute("class", "btn btn-primary");
    inputButton.setAttribute("value", "Discard");
    inputButton.setAttribute("onClick", "discardPhoto()");

    document.getElementById('imageResult').innerHTML = "";
    document.getElementById('imageResult').appendChild(br1);
    document.getElementById('imageResult').appendChild(img);
    document.getElementById('imageResult').appendChild(br2);
    document.getElementById('imageResult').appendChild(br3);
    document.getElementById('imageResult').appendChild(br4);
    document.getElementById('imageResult').appendChild(inputButton);
    document.getElementById('imageBase64StringField').value = editedImage.split(",")[1];
}

// Create elements with the result of editing the form - InputFile
function showInputFileModifications() {
    let img = document.createElement("img");
    img.setAttribute("src", `${editedImage}`);
    img.style.cssText = "width:200px; height:90%;";

    document.getElementById('btnInputFile').innerHTML = "";
    document.getElementById('btnInputFile').appendChild(img);
    document.getElementById('imageBase64StringField').value = editedImage.split(",")[1];
}

// Clear the imageResult div and the imageBase64StringField input
function discardPhoto() {
    image = "";
    editedImage = "";
    document.getElementById('imageResult').innerHTML = "";
    document.getElementById('imageBase64StringField').value = "";
}

// Get selected file in input file
// #imageBase64StringField receives the treated base64String of the last photo selected
function getFileFromInputFile(elemento) {
    const file = elemento.files[0];
    const reader = new FileReader();
    reader.onloadend = function () {
        image = reader.result;
        editedImage = reader.result;
        showModalImageCustomization(image);
    }
    reader.readAsDataURL(file);
}