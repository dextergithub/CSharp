
atgadps.dll: dlldata.obj atgad_p.obj atgad_i.obj
	link /dll /out:atgadps.dll /def:atgadps.def /entry:DllMain dlldata.obj atgad_p.obj atgad_i.obj \
		kernel32.lib rpcndr.lib rpcns4.lib rpcrt4.lib oleaut32.lib uuid.lib \

.c.obj:
	cl /c /Ox /DWIN32 /D_WIN32_WINNT=0x0400 /DREGISTER_PROXY_DLL \
		$<

clean:
	@del atgadps.dll
	@del atgadps.lib
	@del atgadps.exp
	@del dlldata.obj
	@del atgad_p.obj
	@del atgad_i.obj
