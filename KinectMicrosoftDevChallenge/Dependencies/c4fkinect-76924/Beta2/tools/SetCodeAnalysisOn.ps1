$codeAnalysisState = "true";
$root = Split-Path -parent $MyInvocation.MyCommand.Definition

$currentPath = [System.IO.Directory]::GetParent($root).FullName;

$projectFiles = [System.IO.Directory]::GetFiles($currentPath, "*.csproj", [System.IO.SearchOption]::AllDirectories);

echo "Project Count: " $projectFiles.Length;

foreach($file in $projectFiles)
{
	$text = [System.IO.File]::ReadAllText($file);
	$text = $text -replace "(?<=<RunCodeAnalysis>)([\w\.]+)(?=</RunCodeAnalysis>)", $codeAnalysisState;
	[System.IO.File]::WriteAllText($file, $text);
}

echo "Done!";
echo "Code Analysis Turned ON";