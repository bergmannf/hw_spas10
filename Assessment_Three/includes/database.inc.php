<?php

define('DB_USER', 'user');
define('DB_PASSWORD', 's3cr3t');
define('DB_HOST', 'localhost');
define('DB_NAME', 'bookstore');

$dbc = mysqli_connect(DB_HOST, DB_USER, DB_PASSWORD, DB_NAME);

function escape_data($data)
{
	global $dbc;
	if (get_magic_quotes_gpc ())
	{
		$data = mysql_real_escape_string($trim($data), $dbc);
	}
}

function get_password_hash($password)
{
	global $dbc;
	return mysqli_escape_string($dbc, hash_hmac('SHA256', $password, 'macsbooksstore', true));
}
?>