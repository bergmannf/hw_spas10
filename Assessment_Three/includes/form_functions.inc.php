<?php

/**
 * Creates a form-element with the given inputs.
 *
 * @param <type> $name
 * @param <type> $type
 * @param <type> $errors
 */
function create_form_input($name, $type, $errors) {
	$value = null;
	if (isset($_POST[$name])) {
		$value = $_POST[$name];
		if ($value && get_magic_quotes_gpc()) {
			$value = stripslashes($value);
		}
	}
	if ($type == 'text' || $type == 'password') {
		echo '<input type="' . $type . '"name="' . $name . '"id="' . $name . '"';
	}
	if ($value) {
		echo 'value="' . htmlspecialchars($value) . '"';
	}
	if (array_key_exists($name, $errors)) {
		echo 'class="error"/><span class="error">', $errors[$name] . '</span>';
	} else {
		echo '/>';
	}
}