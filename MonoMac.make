

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=.

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/ImageKitDemo.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

IMAGEKITDEMO_EXE_MDB_SOURCE=bin/Debug/ImageKitDemo.exe.mdb
IMAGEKITDEMO_EXE_MDB=$(BUILD_DIR)/ImageKitDemo.exe.mdb
MONOMAC_DLL_SOURCE=../../../../Volumes/Xamarin\ Studio/Xamarin\ Studio.app/Contents/MacOS/lib/monodevelop/AddIns/MonoDevelop.MonoMac/MonoMac.dll

endif

ifeq ($(CONFIG),RELEASE)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/ImageKitDemo.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

IMAGEKITDEMO_EXE_MDB=
MONOMAC_DLL_SOURCE=../../../../Volumes/Xamarin\ Studio/Xamarin\ Studio.app/Contents/MacOS/lib/monodevelop/AddIns/MonoDevelop.MonoMac/MonoMac.dll

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(IMAGEKITDEMO_EXE_MDB) \
	$(MONOMAC_DLL)  

BINARIES = \
	$(MONOMAC)  


RESGEN=resgen2

MONOMAC_DLL = $(BUILD_DIR)/MonoMac.dll
MONOMAC = $(BUILD_DIR)/monomac

FILES = \
	MainWindow.cs \
	MainWindowController.cs \
	MainWindow.xib.designer.cs \
	Main.cs \
	AppDelegate.cs \
	MainMenu.xib.designer.cs \
	BrowseItem.cs \
	BrowseData.cs \
	DragDelegate.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	Info.plist \
	Readme.txt \
	monomac.in 

REFERENCES =  \
	System \
	System.Xml \
	System.Core \
	System.Xml.Linq \
	System.Drawing \
	-pkg:monomac

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

#Targets
all-local: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make



$(eval $(call emit-deploy-target,MONOMAC_DLL))
$(eval $(call emit-deploy-wrapper,MONOMAC,monomac,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(IMAGEKITDEMO_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(MONOMAC_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(bindir)'
	$(call cp,$(MONOMAC),$(DESTDIR)$(bindir))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(IMAGEKITDEMO_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MONOMAC_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MONOMAC),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)
