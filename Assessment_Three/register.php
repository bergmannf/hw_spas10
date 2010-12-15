<?php
require './includes/config.inc.php';
$page_title = 'Register';
include './includes/header.php';
include './includes/sidebar.php';

require MYSQL;
require './includes/form_functions.inc.php';

$reg_errors = array();
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
	$first_name = $_POST['first_name'];
	$first_name = mysqli_escape_string($dbc, $first_name);

	$last_name = $_POST['last_name'];
	$last_name = mysqli_escape_string($dbc, $last_name);

	$username = $_POST['username'];
	$username = mysqli_escape_string($dbc, $username);

	$password = $_POST['pass1'];
	$validation_password = $_POST['pass2'];
	if ($password == $validation_password) {
		$password = mysqli_escape_string($dbc, $password);
	} else {
		$reg_errors['pass2'] = 'The entered passwords did not match.';
	}

	if (empty($reg_errors)) {
		$query = "SELECT C_USERNAME FROM customers WHERE C_USERNAME='$username'";
		$result = mysqli_query($dbc, $query);
		$rows = mysqli_num_rows($result);
		if ($rows == 0) {
			$query = "INSERT INTO customers(C_FNAME, C_LNAME, C_USERNAME, C_PASSWORD) VALUES ('$first_name', '$last_name', '$username','" . get_password_hash($password) . "')";
			$result = mysqli_query($dbc, $query);
			if (mysqli_affected_rows($dbc) == 1) {
?>
				<h3> Thank you for registering</h3>
				<p>You can now log in using your username and password.
					<br/>
								Have fun browsing our catalog.</p>
<?php
				include './includes/footer.php';
				exit ();
			} else {
				trigger_error('There was a system error when trying to register your username. We apologize for the inconvenience. Please try again later.');
			}
		} else {
			$reg_errors['username'] = 'The username is already taken.';
		}
	}
}
?>
<div id="content" class="column-right">
	<h3>Register</h3>
	<p>To access the bookstore it is required to create a user account.
		<br/>
	To create a user account please fill in the form:
	</p>
	<form action="register.php" method="post" accept-charset="utf-8" style="padding-left: 100px">
		<p>
			<label for="first_name"><strong>First Name:</strong></label>
			<br/>
			<?php create_form_input('first_name', 'text', $reg_errors) ?>
		</p>
		<p>
			<label for="last_name"><strong>Last Name:</strong></label>
			<br/>
			<?php create_form_input('last_name', 'text', $reg_errors) ?>
		</p>
		<p>
			<label for="username"><strong>Username:</strong></label>
			<br/>
			<?php create_form_input('username', 'text', $reg_errors) ?>
		</p>
		<p>
			<label for="address"><strong>Address:</strong></label>
			<br/>
			<?php create_form_input('address', 'text', $reg_errors) ?>
		</p>
		<p>
			<label for="pass1"><strong>Password:</strong></label>
			<br/>
			<?php create_form_input('pass1', 'password', $reg_errors) ?>
		</p>
		<p>
			<label for="pass2"><strong>Password (repeat):</strong></label>
			<br/>
			<?php create_form_input('pass2', 'password', $reg_errors) ?>
		</p>
		<p>
			<input type="submit" name="submit_button" value="Next &rarr;" id="submit_button" class="formbutton"/>
		</p>
	</form>
</div>
<?php
			include './includes/footer.php';
?>
