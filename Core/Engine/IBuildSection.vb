Imports System.Drawing
Imports System.Collections.Generic

''' <summary>
''' Define section build interface
''' </summary>
''' <remarks></remarks>
Public Interface IBuildSection
    ReadOnly Property Section As IBaseSection

    ''' <summary>
    ''' For a group section, indicates related header or footer
    ''' </summary>
    Property Related() As IBuildSection

    ''' <summary>
    ''' If returns true, section can be build
    ''' </summary>
    Function CanBuild() As Boolean

    ''' <summary>
    ''' Perform section build
    ''' </summary>
    Function Build() As SectionBuilderResult

End Interface
