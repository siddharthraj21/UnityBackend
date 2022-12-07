<?php
$servername = "localhost";
$username = "root";
$password  = "";
$dbname = "unitybackend";


$Att= $_POST["Att"];
$id = $_POST["id"];
$val = $_POST["val"];
$Atts = array("Fat", "Slimness");
echo $Att;
echo $id;  
echo $val;
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "UPDATE Customizations SET ".$Att." = '".$val."' WHERE id = '".$id."' ";
$result = $conn->query($sql);





/*
if ($result->num_rows > 0) {
    // output data of each row
    echo "username is already taken";
  } else {
    $sql2 = "INSERT INTO users (username, password) VALUES ('".$loginUser."', '".$loginPass."')";
    if ($conn->query($sql2) === TRUE) {
        echo "New record created successfully";
      } else {
        echo "Error: " . $sql2  . "<br>" . $conn->error;
      }
  }
*/
  $conn->close();

?>

