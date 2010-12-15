<?php

require_once 'shopping_cart.php';

$login_errors = array();

$username = $_POST['username'];
$password = $_POST['password'];
if (!empty($username)) {
	if (!empty($password)) {
		$result = get_users_by_username_and_password($username, $password);
		if (count($result) == 1) {
			$user = $result[0];
			$_SESSION['user'] = $user;
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
