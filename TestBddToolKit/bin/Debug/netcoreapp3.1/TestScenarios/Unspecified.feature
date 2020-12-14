Feature: Unspecified

  # Status: Passed
  Scenario: Puede consignar 150 con saldo 1000
    Given tengo un cuenta bancaria con saldo inicial de 1000
    When consigno 150
    Then mi nuevo saldo es 1150
