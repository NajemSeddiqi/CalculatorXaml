   M S B A M L   `   `   `  ����E  AWeatherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WeatherApp.ViewsWeatherApp.Views  5   	   =#clr-namespace:WeatherApp.ViewModelsWeatherApp.ViewModels  5   	   [2clr-namespace:WeatherApp.ViewModels.ValueConverter$WeatherApp.ViewModels.ValueConverter  5   	   $    WeatherApp.Views.WeatherWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WeatherApp.Views     5   	   2vm#clr-namespace:WeatherApp.ViewModels     5   	   I
converters2clr-namespace:WeatherApp.ViewModels.ValueConverter     5   	     � Title$  WeatherWindow��5
   	   $	��600��6   $	��450��6,    � 	Resources 5      %   WeatherApp.ViewModels.WeatherVM   vm>   8WeatherApp.ViewModels.ValueConverter.BoolToRainConverter  
boolToRain��%:   &	        &	        5   
   6     5   
   6)   5      .��5      � $��10,10,10,10q�6    � DataContext# [  6     � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� .+�5      �� $��Search for a city:��6   �� 5      ��6   �� *Query+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5      $
��0,10q�6   $��Search��6#   ��5      �� *SearchCommand+��5      �� *Query+�� 5      ��6   �� *Cities+ �� SelectedValue 5      �� *SelectedCity+��5      �� 5      .R�5      � .+�5       �� ��6(   �� *LocalizedName+5!      5"      5$      5%      � 5&   
   $��1��6   ���#4392f1 5(      �� *CurrentConditions+ � ColumnDefinitions 5)      �� 5*      $��* �6#   �� 5+      $
��auto �6#   .+�5-      �� $
��0,10q�6   .+�5.      �� # [  6   ���#f4f4f8$��20(�51      $
��20,0q�52      ��5/      �� *SelectedCity.LocalizedName+52      �� 53      ���#f4f4f8$��18(�55      $
��20,0q�56      ��53      �� *CurrentConditions.WeatherText+56      �� 57      ���#f4f4f8$��16(�5:      $
��20,0q�5;      ��57      �� *#!CurrentCondition.HasPrecipitation+ �� 	Converter# [ 5;      5<      �� 5=      $��1��6   $��Center=�5>      ���#f4f4f8$��30(�5A      $
��20,0q�5B      ��5?      �� *Temperature.Metric.Value+	 �� StringFormat$	 {0}°C��5B      5C      5D      5E      