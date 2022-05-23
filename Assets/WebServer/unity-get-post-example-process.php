<!DOCTYPE html>
<html>
<body>

<?php
	echo $_POST["answer-index"];
	echo "<br>";
	$fileContents = file_get_contents("unity-get-post-example-process.txt");
	echo $fileContents;
	echo "<br>";
	
	$textArray = explode(",", $fileContents);
	$txt = "";
	$arrLength = count($textArray);
	echo $textArray;
	echo "<br>";
	echo $arrLength;
	echo "<br>";
	for($x = 0; $x < $arrLength; $x++) {
		if ($x == $_POST["answer-index"]) {
			$newVal = $textArray[$x] + 1;
			$txt = $txt . $newVal;
		} else {
			$txt = $txt . $textArray[$x];
		}	
		if ($x != $arrLength - 1) {
			$txt = $txt . ",";
		}
	}
	$myfile = fopen("unity-get-post-example-process.txt", "w") or die("Unable to open file!");
	fwrite($myfile, $txt);
	fclose($myfile);
?>

</body>
</html>