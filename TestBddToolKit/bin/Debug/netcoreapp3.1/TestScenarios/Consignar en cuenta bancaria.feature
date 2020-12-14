@tag1 @tag2
Feature: Consignar en cuenta bancaria

  Optional description

  Rule: Consignacion correcta

    Optional description

    # Status: Passed
    @tag3 @tag4
    Scenario: Puede consignar 150 con saldo 1000
      Given tengo un cuenta bancaria con saldo inicial de 1000
      When consigno 150
      Then mi nuevo saldo es 1150

    # Status: Passed
    @tag3 @tag4
    Scenario: Puede consignar 200 con saldo 1000
      Given tengo un cuenta bancaria con saldo inicial de 1000
      When consigno 200
      Then mi nuevo saldo es 1200

    # Status: Failed
    @tag3 @tag4
    Scenario: Puede consignar 200 con saldo 1000
      Given tengo un cuenta bancaria con saldo inicial de 1000
      When consigno 100
      Then mi nuevo saldo es 1200
