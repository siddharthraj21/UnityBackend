<?php
$servername = "localhost";
$username = "root";
$password  = "";
$dbname = "UnityBackend";

//username and password submitted by users
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT username FROM user where username = '".$loginUser."'";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    // output data of each row
    echo "username is already taken";
  } else {
    $sql2 = "INSERT INTO user (username, password, level, coins) VALUES ('".$loginUser."', '".$loginPass."', 1, 0)";
    if ($conn->query($sql2) === TRUE) {
        echo "New record created successfully";
      } else {
        echo "Error: " . $sql2  . "<br>" . $conn->error;
      }
  }
  $conn->close();

?>