<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "UnityBackend";


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "The following are the players usernames and levels". "<br>";
$sql = "SELECT level FROM user";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      echo "username: " . $row["username"]. " - level: " . $row["level"]. " " . "<br>";
    }
  } else {
    echo "0 results";
  }
  $conn->close();

?>