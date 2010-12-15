<?php

include_once 'user.php';

define('DB_USER', 'fhb2');
define('DB_PASSWORD', 'fhb2');
define('DB_HOST', 'localhost');
define('DB_NAME', 'fhb2');

$dbc = mysqli_connect(DB_HOST, DB_USER, DB_PASSWORD, DB_NAME);

function escape_data($data) {
	global $dbc;
	if (get_magic_quotes_gpc ()) {
		$data = mysql_real_escape_string($trim($data), $dbc);
	}
}

function get_password_hash($password) {
	global $dbc;
	return mysqli_escape_string($dbc, hash_hmac('SHA256', $password, 'macsbooksstore', true));
}

function get_users_by_username_and_password($username, $password) {
	global $dbc;
	$users = array();
	$query = "SELECT C_ID, C_USERNAME, C_FNAME, C_LNAME, C_ADD FROM customers WHERE C_USERNAME = '$username' AND C_PASSWORD = '" . get_password_hash($password) . "'";
	$result = mysqli_query($dbc, $query);
	while ($row = $result->fetch_row()) {
		$user = new User();
		$user->userId = $row[0];
		$user->username = $row[1];
		$user->firstName = $row[2];
		$user->lastName = $row[3];
		$user->address = $row[4];
		array_push($users, $user);
	}
	return $users;
}

/**
 *
 * @global <type> $dbc
 * @return array
 */
function get_all_items() {
	global $dbc;
	$items = array();
	$query = "SELECT I_ID, I_TITLE, I_A_ID, I_PUBLISHER, I_SUBJECT, I_COST, I_STOCK FROM items";
	$result = mysqli_query($dbc, $query);
	while ($row = $result->fetch_row()) {
		$itemId = $row[0];
		$quantity = 0;
		$title = $row[1];
		$authorId = $row[2];
		$publisher = $row[3];
		$subject = $row[4];
		$cost = $row[5];
		$stock = $row[6];
		$item = new Item($itemId, $quantity, $title, $authorId, $publisher, $subject, $cost, $stock);
		array_push($items, $item);
	}
	return $items;
}

/**
 *
 * @param <type> $query
 * @param <type> $category
 */
function search_items($query, $category=null) {
	global $dbc;
	$items = array();
	$query = "SELECT I_ID, I_TITLE, I_A_ID, I_PUBLISHER, I_SUBJECT, I_COST, I_STOCK FROM items";
	$result = mysqli_query($dbc, $query);
	while ($row = $result->fetch_row()) {
		$itemId = $row[0];
		$quantity = 0;
		$title = $row[1];
		$authorId = $row[2];
		$publisher = $row[3];
		$subject = $row[4];
		$cost = $row[5];
		$stock = $row[6];
		$item = new Item($itemId, $quantity, $title, $authorId, $publisher, $subject, $cost, $stock);
		array_push($items, $item);
	}
	return $items;
}

?>