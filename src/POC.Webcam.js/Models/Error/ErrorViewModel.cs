namespace POC.Webcam.js.Models.Error;

public class ErrorViewModel
{
    public string RequestId { get; set; }
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}