<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="TaskList">
    <xsl:copy>
      <xsl:apply-templates select="Task"/>
    </xsl:copy>
  </xsl:template>
  
  <xsl:template match="Task">
    <Task>
      <xsl:attribute name="TaskId">
        <xsl:value-of select="TaskId"/>
      </xsl:attribute>
      <xsl:attribute name="TaskName">
        <xsl:value-of select="TaskName"/>
      </xsl:attribute>
    </Task>
  </xsl:template>
  
</xsl:stylesheet>
