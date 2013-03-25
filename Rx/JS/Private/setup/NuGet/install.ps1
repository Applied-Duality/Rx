param($installPath, $toolsPath, $package, $project)

$project.ProjectItems | ForEach { if ($_.Name -eq "dummy.txt") { $_.Delete() } }