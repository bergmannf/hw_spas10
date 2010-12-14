<?php

require_once 'shopping_cart.php';

$login_errors = array();

$username = $_POST['username'];
$password = $_POST['password'];
if (!empty($username)) {
	if (!empty($password)) {
		$username = mysqli_escape_string($dbc, $username);
		$password = mysqli_escape_string($dbc, $username);
		$query = "SELECT C_USERNAME FROM customers WHERE C_USERNAME = '$username' AND C_PASSWORD = '" . get_password_hash($password) . "'";
		$result = mysqli_query($dbc, $query);
		if (mysqli_num_rows($result) == 1) {
			$row = mysqli_fetch_row($result);
			$_SESSION['user_id'] = $row[0];
			$_SESSION['cart'] = new ShoppingCart();
		} else {
			$login_errors['login'] = 'The username and password do not match';
		}
	} else {
		$login_errors['password'] = 'Please enter a password';
	}
} else {
	$login_errors['username'] = 'Please enter a username';
}
?>
