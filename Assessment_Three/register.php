<?php
require './includes/config.inc.php';
$page_title = 'Register';
include './includes/header.php';
include './includes/sidebar.php';

require MYSQL;
require_once './includes/form_functions.inc.php';

$reg_errors = array();
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
	$first_name = $_POST['first_name'];
	if (empty ($first_name)) {
		$reg_errors['first_name'] = 'Please enter a first name.';
	}

	$last_name = $_POST['last_name'];
	if (empty ($last_name))
	{
		$reg_errors['last_name'] = 'Please enter a last name.';
	}

	$username = $_POST['username'];
	if (empty ($username)){
		$reg_errors['username'] = 'Please enter a username.';
	}

	$address = $_POST['address'];
	if (empty ($address)){
		$reg_errors['address'] = 'Please enter an address.';
	}

	$password = $_POST['pass1'];
	$validation_password = $_POST['pass2'];
	if (!($password == $validation_password)) {
		$reg_errors['pass2'] = 'The entered passwords did not match.';
	}

	if (empty($reg_errors)) {
		$result = get_users_by_username_and_password($username);
		if (count($result) == 0) {
			$insert = insert_user_into_database($first_name, $last_name, $address, $username, $password);
			if ($insert) {
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
