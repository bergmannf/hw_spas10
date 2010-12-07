<?php

require_once('MDB2.php');

function connect() {
	$con = MDB2::factory($url);
	if (PEAR::isError($con)) {
		die("Error while connecting to database " . $con->getMessage());
	}
	return $con;
}

function execute_query($sql, $values=array()) {
	$con = connect();
	if (sizeof($values) > 0) {
		$statement = $con->prepare($sql, TRUE, MDB2_PREPARE_RESULT);
		$resultset = $statement->execute($values);
		$statement->free();
	} else {
		$resultset = $con->query($sql);
	}
	if (PEAR::isError($resultset)) {
		die('DB Error... ' . $resultset->getMessage());
	}

	while ($row = $resultset->fetchRow(MDB2_FETCHMODE_ASSOC)) {
		$results[] = $row;
	}
	return $results;
}

?>
