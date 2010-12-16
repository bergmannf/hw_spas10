<?php

include_once 'user.php';

define('DB_USER', 'fhb2');
define('DB_PASSWORD', 'fhb2');
define('DB_HOST', 'localhost');
define('DB_PORT', 8889);
define('DB_NAME', 'fhb2');

$dbc = mysqli_connect(DB_HOST, DB_USER, DB_PASSWORD, DB_NAME);

/**
 *
 * @global  $dbc
 * @param <type> $data
 * @return <type>
 */
function escape_data($data) {
	global $dbc;
	return mysql_real_escape_string($trim($data), $dbc);
}

/**
 * Creates a password hash for the provided string and returns it.
 *
 * @global  $dbc
 * @param <type> $password The password that shall be hashed.
 * @return <type> The hashed password in binary form.
 */
function get_password_hash($password) {
	global $dbc;
	return mysqli_escape_string($dbc, hash_hmac('SHA256', $password, 'macsbooksstore', true));
}

/**
 * Will return an array with the user(s) corresponding to the username and password provided.
 *
 * @global  $dbc
 * @param <type> $username The username that shall be queried.
 * @param <type> $password The password that shall be queried.
 * @return array The array with the user(s)
 */
function get_users_by_username_and_password($username, $password=null) {
	global $dbc;
	$users = array();
	$query = "SELECT C_ID, C_USERNAME, C_FNAME, C_LNAME, C_ADD FROM customers WHERE C_USERNAME = '$username'";
	if (isset ($password))
	{
		$query .=  "AND C_PASSWORD = '" . get_password_hash($password) . "'";
	}
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
 * Will return a list of all items that correspond to the search-criterion.
 *
 * @param <type> $search The string that will be matched.
 * @param <type> $category The category of the matching.
 * @return A list of items that fulfill the search criterion.
 */
function search_items($search, $category=null) {
	global $dbc;
	$items = array();
	$query;
	if (isset($category)) {
		$query = "SELECT i.I_ID, i.I_TITLE, i.I_A_ID, i.I_PUBLISHER, i.I_SUBJECT, i.I_COST, i.I_STOCK FROM items i, authors a WHERE I_A_ID = A_ID AND ";
		switch ($category) {
			case 'Title':
				$query.= "i.I_TITLE like '%$search%'";
				break;
			case 'Author':
				$query.= "a.A_FNAME like '%$search%' OR a.A_LNAME like '%$search%'";
				break;
			case 'Publisher':
				$query.= "i.I_PUBLISHER like '%$search%'";
				break;
			case 'Topic':
				$query.= "i.I_SUBJECT like '%$search%'";
				break;
			default:
				$query = "SELECT DISTINCT i.I_ID, i.I_TITLE, i.I_A_ID, i.I_PUBLISHER, i.I_SUBJECT, i.I_COST, i.I_STOCK FROM items i, authors a WHERE I_A_ID = A_ID AND ";
				$query .= "i.I_TITLE like '%$search%' OR i.I_PUBLISHER like '%$search%' OR i.I_SUBJECT like '%$search%' OR a.A_FNAME like '%$search%' OR a.A_LNAME like '%$search%'";
		}
	} else {
		$query = "SELECT DISTINCT i.I_ID, i.I_TITLE, i.I_A_ID, i.I_PUBLISHER, i.I_SUBJECT, i.I_COST, i.I_STOCK FROM items i, authors a WHERE I_A_ID = A_ID AND I_A_ID = A_ID AND ";
		$query .= "i.I_TITLE like '%$search%' OR i.I_PUBLISHER like '%$search%' OR i.I_SUBJECT like '%$search%' OR a.A_FNAME like '%$search%' OR a.A_LNAME like '%$search%'";
	}
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
 * Will return the product corresponding to the provided id.
 *
 * @global  $dbc The connection to the database.
 * @param <type> $productId The productId of the product that shall be retrieved.
 * @return Item The product that was retrieved from the database.
 */
function get_product_by_id($productId) {
	global $dbc;
	$item;
	$query = "SELECT I_ID, I_TITLE, A_FNAME, A_LNAME, I_PUBLISHER, I_SUBJECT, I_COST, I_STOCK FROM items, authors WHERE items.I_A_ID = authors.A_ID AND items.I_ID = '$productId'";
	$result = mysqli_query($dbc, $query);
	$row = $result->fetch_row();
	$itemId = $row[0];
	$quantity = 0;
	$title = $row[1];
	$authorId = $row[2] . ' ' . $row[3];
	$publisher = $row[4];
	$subject = $row[5];
	$cost = $row[6];
	$stock = $row[7];
	$item = new Item($itemId, $quantity, $title, $authorId, $publisher, $subject, $cost, $stock);
	return $item;
}

/**
 * Inserts a user into the database with the provided parameters.
 *
 * @param <type> $first_name The first name.
 * @param <type> $last_name The last name.
 * @param <type> $address The address.
 * @param <type> $username The username.
 * @param <type> $password The password.
 * @return <type> Returns true if insert successful, false otherwise.
 */
function insert_user_into_database($first_name, $last_name, $address, $username, $password){
	global $dbc;
	$query = "INSERT INTO customers(C_FNAME, C_LNAME, C_ADD, C_USERNAME, C_PASSWORD) VALUES ('$first_name', '$last_name', '$address', '$username', '" . get_password_hash($password) . "')";
	$result = mysqli_query($dbc, $query);
	if (mysqli_affected_rows ($dbc) == 1)
	{
		return true;
	}
	else {
		return false;
	}
}

?>