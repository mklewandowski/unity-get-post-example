<!DOCTYPE html>
<html>
<body>

<?php
	echo "Answer successfully submitted!";
	echo "<br>";
	echo "Your answer index is:";
	echo "<br>";
	echo $_POST["answer-index"];
	echo "<br>";
	$fileContents = file_get_contents("unity-get-post-example-process.txt");
	echo "Previous contents of CSV text file:";
	echo "<br>";
	echo $fileContents;
	echo "<br>";
	
	$textArray = explode(",", $fileContents);
	$txt = "";
	$arrLength = count($textArray);
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
	echo "New contents of CSV text file:";
	echo "<br>";
	echo $txt;
	echo "<br>";
	$myfile = fopen("unity-get-post-example-process.txt", "w") or die("Unable to open file!");
	fwrite($myfile, $txt);
	fclose($myfile);
?>
The <a href="unity-get-post-example-process.txt">CSV text file</a> with the answers can be seen <a href="unity-get-post-example-process.txt">here</a> (you might need to refresh your browser to see the latest values).

</body>
</html>