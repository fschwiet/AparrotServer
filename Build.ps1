$v4_net_version = (ls "$env:windir\Microsoft.NET\Framework\v4.0*").Name
&"C:\Windows\Microsoft.NET\Framework\$v4_net_version\MSBuild.exe"
