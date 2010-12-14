<?php
if (!isset($login_errors)) {
	$login_errors = array();
}
require_once './includes/form_functions.inc.php';
?>
<div class="title">
	<form action="index.php" method="post" accept-charset="utf-8">
		<p>
			<?php
			if (array_key_exists('login', $login_errors)) {
				echo '<span class="error">' . $login_errors['login'] . '</span><br/>';
			}
			?>
			<label for="username">
				<strong>Username:</strong>
			</label>
			<br/>
			<?php create_form_input('username', 'text', $login_errors); ?>
			<br/>
			<label for="password">
				<strong>Password:</strong>
			</label>
			<br/>
			<?php create_form_input('password', 'password', $login_errors); ?>
			<br/>
			<input type="submit" value="Login &rArr;" class="formbutton" />
		</p>
	</form>
</div>
