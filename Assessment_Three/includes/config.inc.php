<?php

$live = false;

define('BASE_URI', '/Assessment_Three');
// TODO: Change before deployment
define('BASE_URL', 'localhost/Assessment_Three/');
define('MYSQL', './includes/database.inc.php');

include_once('user.php');
include_once('item.php');
include_once('shopping_cart.inc.php');

session_start();

function error_handler($e_number, $e_message, $e_file, $e_line, $e_vars) {
	global $live;
	$message = "An error occured in script $e_file on line $e_line: $e_message";
	$message .= "<pre>" . print_r(debug_backtrace(), true) . "<pre>\n";

	if (!$live) {
		echo '<div class="error">' . nl2br($message) . '<div>';
	} else {
		// TODO: handle error when site was live: send email.
	}
	return true;
}

set_error_handler('error_handler');

/**
 * Will redirect the user to another page if the check variable is not set in the session.
 *
 * @param <type> $check The variable the session should be checked for.
 * @param <type> $destination The redirection url.
 * @param <type> $protocol The protocol to use to redirect the user.
 */
function redirect_invalid_user($check = 'user', $destination = 'index.php', $protocol = 'http://') {
	if (!isset($_SESSION[$check])) {
		$url = $protocol . BASE_URL . $destination . '?invalid=true';
		header("Location:$url");
		exit();
	}
}
?>