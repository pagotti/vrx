<Flags>
Public Enum DisplayOption
    Never = 0
    OnPreview = 1 << 0
    OnReport = 1 << 1
    OnFile = 1 << 2
    OnPreviewAndReport = OnPreview Or OnReport
    OnPreviewAndFile = OnPreview Or OnFile
    OnReportAndFile = OnReport Or OnFile

    Always = -1
End Enum
